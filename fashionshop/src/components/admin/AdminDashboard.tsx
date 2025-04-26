import React from 'react';
import { Link } from 'react-router-dom';
// filepath: d:\Reacte\fashionshop\src\main.tsx
import 'bootstrap/dist/css/bootstrap.min.css';
function AdminDashboard() {
  return (
    <div className="container py-5">
      <h1 className="text-center mb-4">Trang Quản Trị</h1>

      <div className="d-flex flex-column align-items-center gap-3">
        <Link to="/admin/products" className="btn btn-primary w-50">
          📦 Quản lý Sản phẩm
        </Link>
        <Link to="/admin/categories" className="btn btn-success w-50">
          📂 Quản lý Danh mục
        </Link>
        <Link to="/admin/brands" className="btn btn-warning w-50">
          🏷️ Quản lý Thương hiệu
        </Link>
      </div>
    </div>
  );
}

export default AdminDashboard;
