import React, { useState, useEffect } from 'react';
import { getCategories, addCategory, updateCategory, deleteCategory } from '../../../api/admin/categoryService'; // Import các hàm từ categoryService
import { useNavigate } from 'react-router-dom'; // Import useNavigate

interface Category {
  id: number;
  name: string;
  description: string;
  imageUrl: string;
}

function CategoryManager() {
  const [categories, setCategories] = useState<Category[]>([]);
  const [newCategoryName, setNewCategoryName] = useState('');
  const [newCategoryDescription, setNewCategoryDescription] = useState('');  // Thêm state cho mô tả
  const [newCategoryImage, setNewCategoryImage] = useState<File | null>(null);  // Thêm state cho hình ảnh
  const [editingCategory, setEditingCategory] = useState<Category | null>(null);
  const navigate = useNavigate();  // Khai báo useNavigate

  useEffect(() => {
    fetchCategories();
  }, []);

  const fetchCategories = async () => {
    const data = await getCategories();
    setCategories(data);
  };

  const handleAddCategory = async () => {
    if (newCategoryName.trim() === '') return;

    // Nếu có ảnh, tải lên
    let imageUrl = '';
    if (newCategoryImage) {
      const formData = new FormData();
      formData.append('image', newCategoryImage);
      // Giả sử bạn có API upload ảnh và nhận lại URL của ảnh
      const uploadedImageUrl = await uploadImage(formData); // Gọi API upload ảnh
      imageUrl = uploadedImageUrl;
    }

    const createdCategory = await addCategory({
      name: newCategoryName,
      description: newCategoryDescription,
      imageUrl,
    });

    setCategories([...categories, createdCategory]);
    setNewCategoryName('');
    setNewCategoryDescription('');
    setNewCategoryImage(null);
  };

  const handleUpdateCategory = async () => {
    if (editingCategory) {
      const updated = await updateCategory(editingCategory.id, {
        name: editingCategory.name,
        description: editingCategory.description,
        imageUrl: editingCategory.imageUrl,
      });
      setCategories(categories.map(c => c.id === updated.id ? updated : c));
      setEditingCategory(null);
    }
  };

  const handleDeleteCategory = async (id: number) => {
    await deleteCategory(id);
    setCategories(categories.filter(c => c.id !== id));
  };

  // Giả sử bạn có một API upload ảnh
  const uploadImage = async (formData: FormData) => {
    // Gọi API upload ảnh và trả về URL
    return 'http://localhost:5085/images/category-uploaded.jpg'; // URL giả
  };

  // Hàm quay lại trang Admin
  const handleGoBack = () => {
    navigate('/admin');  // Chuyển hướng về trang Admin Dashboard
  };

  return (
    <div className="container py-4">
      <h2>Quản lý Danh mục</h2>

      {/* Nút quay lại trang Admin */}
      <button className="btn btn-secondary mb-4" onClick={handleGoBack}>Quay lại trang Admin</button>

      {/* Table Danh mục */}
      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Tên danh mục</th>
            <th>Mô tả</th>
            <th>Hình ảnh</th>
            <th>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {categories.map((category) => (
            <tr key={category.id}>
              <td>{category.id}</td>
              <td>{category.name}</td>
              <td>{category.description}</td>
              <td>
                {category.imageUrl && <img src={category.imageUrl} alt={category.name} width="50" />}
              </td>
              <td>
                <button className="btn btn-warning" onClick={() => setEditingCategory(category)}>Sửa</button>
                <button className="btn btn-danger ms-2" onClick={() => handleDeleteCategory(category.id)}>Xóa</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Form Thêm/Sửa danh mục */}
      <div className="card mt-4">
        <div className="card-body">
          <h5>{editingCategory ? 'Sửa Danh mục' : 'Thêm Danh mục'}</h5>
          <input
            type="text"
            className="form-control"
            placeholder="Tên danh mục"
            value={editingCategory ? editingCategory.name : newCategoryName}
            onChange={e => {
              if (editingCategory) {
                setEditingCategory({ ...editingCategory, name: e.target.value });
              } else {
                setNewCategoryName(e.target.value);
              }
            }}
          />
          <textarea
            className="form-control mt-2"
            placeholder="Mô tả danh mục"
            value={editingCategory ? editingCategory.description : newCategoryDescription}
            onChange={e => {
              if (editingCategory) {
                setEditingCategory({ ...editingCategory, description: e.target.value });
              } else {
                setNewCategoryDescription(e.target.value);
              }
            }}
          />
          <div className="mt-2">
            <input
              type="file"
              className="form-control"
              onChange={e => {
                if (e.target.files) {
                  setNewCategoryImage(e.target.files[0]);
                }
              }}
            />
          </div>
          <button
            className="btn btn-primary mt-3"
            onClick={editingCategory ? handleUpdateCategory : handleAddCategory}
          >
            {editingCategory ? 'Cập nhật danh mục' : 'Thêm danh mục'}
          </button>
        </div>
      </div>
    </div>
  );
}

export default CategoryManager;
