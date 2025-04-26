import React, { useEffect, useState } from 'react';
import { getProducts, addProduct, updateProduct, deleteProduct } from '../../../api/admin/productService';
import { getCategories } from '../../../api/admin/categoryService';
import { getBrands } from '../../../api/admin/brandService';

interface Product {
  id: number;
  name: string;
  price: number;
  description: string;
  image: string;
  categoryId: number;
  brandId: number;
}

interface Category {
  id: number;
  name: string;
}

interface Brand {
  id: number;
  name: string;
}

function ProductManager() {
  const [products, setProducts] = useState<Product[]>([]);
  const [categories, setCategories] = useState<Category[]>([]);
  const [brands, setBrands] = useState<Brand[]>([]);
  const [newProduct, setNewProduct] = useState<Omit<Product, 'id' | 'image'>>({
    name: '',
    price: 0,
    description: '',
    categoryId: 0,
    brandId: 0,
  });
  const [imageFile, setImageFile] = useState<File | null>(null);
  const [editingProduct, setEditingProduct] = useState<Product | null>(null);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    const [prodRes, catRes, brandRes] = await Promise.all([
      getProducts(),
      getCategories(),
      getBrands(),
    ]);
    setProducts(prodRes);
    setCategories(catRes);
    setBrands(brandRes);
  };

  const handleAddProduct = async () => {
    if (!imageFile) return alert('Vui lòng chọn hình ảnh');
    const formData = new FormData();
    formData.append('name', newProduct.name);
    formData.append('price', newProduct.price.toString());
    formData.append('description', newProduct.description);
    formData.append('categoryId', newProduct.categoryId.toString());
    formData.append('brandId', newProduct.brandId.toString());
    formData.append('image', imageFile);

    const created = await addProduct(formData);
    setProducts([...products, created]);
    setNewProduct({
      name: '',
      price: 0,
      description: '',
      categoryId: 0,
      brandId: 0,
    });
    setImageFile(null);
  };

  const handleUpdateProduct = async () => {
    if (!editingProduct) return;

    const formData = new FormData();
    formData.append('name', editingProduct.name);
    formData.append('price', editingProduct.price.toString());
    formData.append('description', editingProduct.description);
    formData.append('categoryId', editingProduct.categoryId.toString());
    formData.append('brandId', editingProduct.brandId.toString());
    if (imageFile) {
      formData.append('image', imageFile);
    }

    const updated = await updateProduct(editingProduct.id, formData);
    setProducts(products.map(p => (p.id === updated.id ? updated : p)));
    setEditingProduct(null);
    setImageFile(null);
  };

  const handleDeleteProduct = async (id: number) => {
    await deleteProduct(id);
    setProducts(products.filter(p => p.id !== id));
  };

  const handleGoBack = () => {
    window.location.href = '/admin'; // Chỉnh đường dẫn này tùy thuộc vào route của trang admin trong ứng dụng của bạn
  };

  return (
    <div className="container py-4">
      <h2>Quản lý Sản phẩm</h2>
 {/* Nút quay lại trang Admin */}
 <button className="btn btn-secondary mb-4" onClick={handleGoBack}>Quay lại trang Admin</button>
      {/* Table sản phẩm */}
      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Hình</th>
            <th>Tên</th>
            <th>Giá</th>
            <th>Danh mục</th>
            <th>Thương hiệu</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {products.map((prod) => (
            <tr key={prod.id}>
              <td>{prod.id}</td>
              <td>
                <img src={`http://localhost:5085/images/product/${prod.image}`} alt={prod.name} width="60" />
              </td>
              <td>{prod.name}</td>
              <td>{prod.price.toLocaleString()} đ</td>
              <td>{categories.find(c => c.id === prod.categoryId)?.name || 'N/A'}</td>
              <td>{brands.find(b => b.id === prod.brandId)?.name || 'N/A'}</td>
              <td>
                <button className="btn btn-warning" onClick={() => setEditingProduct(prod)}>Sửa</button>
                <button className="btn btn-danger ms-2" onClick={() => handleDeleteProduct(prod.id)}>Xóa</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Form Thêm/Sửa sản phẩm */}
      <div className="card mt-4">
        <div className="card-body">
          <h5>{editingProduct ? 'Sửa Sản phẩm' : 'Thêm Sản phẩm'}</h5>

          <input
            type="text"
            className="form-control mb-2"
            placeholder="Tên sản phẩm"
            value={editingProduct ? editingProduct.name : newProduct.name}
            onChange={e => {
              if (editingProduct) setEditingProduct({ ...editingProduct, name: e.target.value });
              else setNewProduct({ ...newProduct, name: e.target.value });
            }}
          />
          <input
            type="number"
            className="form-control mb-2"
            placeholder="Giá sản phẩm"
            value={editingProduct ? editingProduct.price : newProduct.price}
            onChange={e => {
              const value = parseFloat(e.target.value);
              if (editingProduct) setEditingProduct({ ...editingProduct, price: value });
              else setNewProduct({ ...newProduct, price: value });
            }}
          />
          <textarea
            className="form-control mb-2"
            placeholder="Mô tả sản phẩm"
            value={editingProduct ? editingProduct.description : newProduct.description}
            onChange={e => {
              if (editingProduct) setEditingProduct({ ...editingProduct, description: e.target.value });
              else setNewProduct({ ...newProduct, description: e.target.value });
            }}
          ></textarea>

          <select
            className="form-select mb-2"
            value={editingProduct ? editingProduct.categoryId : newProduct.categoryId}
            onChange={e => {
              const value = parseInt(e.target.value);
              if (editingProduct) setEditingProduct({ ...editingProduct, categoryId: value });
              else setNewProduct({ ...newProduct, categoryId: value });
            }}
          >
            <option value="">-- Chọn danh mục --</option>
            {categories.map(c => (
              <option key={c.id} value={c.id}>{c.name}</option>
            ))}
          </select>

          <select
            className="form-select mb-2"
            value={editingProduct ? editingProduct.brandId : newProduct.brandId}
            onChange={e => {
              const value = parseInt(e.target.value);
              if (editingProduct) setEditingProduct({ ...editingProduct, brandId: value });
              else setNewProduct({ ...newProduct, brandId: value });
            }}
          >
            <option value="">-- Chọn thương hiệu --</option>
            {brands.map(b => (
              <option key={b.id} value={b.id}>{b.name}</option>
            ))}
          </select>

          <input
            type="file"
            className="form-control mb-3"
            onChange={e => setImageFile(e.target.files?.[0] || null)}
          />

          <button
            className="btn btn-primary"
            onClick={editingProduct ? handleUpdateProduct : handleAddProduct}
          >
            {editingProduct ? 'Cập nhật sản phẩm' : 'Thêm sản phẩm'}
          </button>
        </div>
      </div>
    </div>
  );
}

export default ProductManager;
