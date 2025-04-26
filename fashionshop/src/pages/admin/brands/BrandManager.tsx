import React, { useState, useEffect } from 'react';
import { getBrands, addBrand, updateBrand, deleteBrand } from '../../../api/admin/brandService'; // Import các hàm từ brandService

interface Brand {
  id: number;
  name: string;
  description: string; 
  image: string; 
}

function BrandManager() {
  const [brands, setBrands] = useState<Brand[]>([]);
  const [newBrandName, setNewBrandName] = useState('');
  const [newBrandDescription, setNewBrandDescription] = useState(''); 
  const [imageFile, setImageFile] = useState<File | null>(null); 
  const [editingBrand, setEditingBrand] = useState<Brand | null>(null);

  useEffect(() => {
    fetchBrands();
  }, []);

  const fetchBrands = async () => {
    const data = await getBrands();
    setBrands(data);
  };

  const handleAddBrand = async () => {
    if (newBrandName.trim() === '') return;
    const formData = new FormData();
    formData.append('name', newBrandName);
    formData.append('description', newBrandDescription);
    if (imageFile) {
      formData.append('image', imageFile);
    }

    const createdBrand = await addBrand(formData);
    setBrands([...brands, createdBrand]);
    setNewBrandName('');
    setNewBrandDescription('');
    setImageFile(null);
  };

  const handleUpdateBrand = async () => {
    if (editingBrand) {
      const formData = new FormData();
      formData.append('name', editingBrand.name);
      formData.append('description', editingBrand.description);
      if (imageFile) {
        formData.append('image', imageFile);
      }

      const updated = await updateBrand(editingBrand.id, formData);
      setBrands(brands.map(b => b.id === updated.id ? updated : b));
      setEditingBrand(null);
      setImageFile(null);
    }
  };

  const handleDeleteBrand = async (id: number) => {
    await deleteBrand(id);
    setBrands(brands.filter(b => b.id !== id));
  };

  const handleGoBack = () => {
    window.location.href = '/admin'; // Chỉnh đường dẫn này tùy thuộc vào route của trang admin trong ứng dụng của bạn
  };

  return (
    <div className="container py-4">
      <h2>Quản lý Thương hiệu</h2>
      {/* Nút quay lại trang Admin */}
      <button className="btn btn-secondary mb-4" onClick={handleGoBack}>Quay lại trang Admin</button>
      {/* Table Thương hiệu */}
      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Tên thương hiệu</th>
            <th>Mô tả</th>
            <th>Hình ảnh</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {brands.map((brand) => (
            <tr key={brand.id}>
              <td>{brand.id}</td>
              <td>{brand.name}</td>
              <td>{brand.description}</td>
              <td>
                <img src={`http://localhost:5085/images/brand/${brand.image}`} alt={brand.name} width="60" />
              </td>
              <td>
                <button className="btn btn-warning" onClick={() => setEditingBrand(brand)}>Sửa</button>
                <button className="btn btn-danger ms-2" onClick={() => handleDeleteBrand(brand.id)}>Xóa</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Form Thêm/Sửa thương hiệu */}
      <div className="card mt-4">
        <div className="card-body">
          <h5>{editingBrand ? 'Sửa Thương hiệu' : 'Thêm Thương hiệu'}</h5>
          <input
            type="text"
            className="form-control mb-2"
            placeholder="Tên thương hiệu"
            value={editingBrand ? editingBrand.name : newBrandName}
            onChange={e => {
              if (editingBrand) {
                setEditingBrand({ ...editingBrand, name: e.target.value });
              } else {
                setNewBrandName(e.target.value);
              }
            }}
          />
          <textarea
            className="form-control mb-2"
            placeholder="Mô tả thương hiệu"
            value={editingBrand ? editingBrand.description : newBrandDescription}
            onChange={e => {
              if (editingBrand) {
                setEditingBrand({ ...editingBrand, description: e.target.value });
              } else {
                setNewBrandDescription(e.target.value);
              }
            }}
          ></textarea>

          <input
            type="file"
            className="form-control mb-3"
            onChange={e => setImageFile(e.target.files?.[0] || null)}
          />

          <button
            className="btn btn-primary"
            onClick={editingBrand ? handleUpdateBrand : handleAddBrand}
          >
            {editingBrand ? 'Cập nhật thương hiệu' : 'Thêm thương hiệu'}
          </button>
        </div>
      </div>
    </div>
  );
}

export default BrandManager;
