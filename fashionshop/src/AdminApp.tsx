import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AdminDashboard from './components/admin/AdminDashboard';
import ProductManager from './pages/admin/products/ProductManager';
import CategoryManager from './pages/admin/categories/CategoryManager';
import BrandManager from './pages/admin/brands/BrandManager';

function App() {
  return (
    <Router>
      <Routes>
        {/* Trang Admin Dashboard */}
        <Route path="/admin" element={<AdminDashboard />} />

        {/* Các trang quản lý */}
        <Route path="/admin/products" element={<ProductManager />} />
        <Route path="/admin/categories" element={<CategoryManager />} />
        <Route path="/admin/brands" element={<BrandManager />} />

        {/* Các route khác */}
      </Routes>
    </Router>
  );
}

export default App;
