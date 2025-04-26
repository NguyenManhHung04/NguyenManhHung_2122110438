import axios from 'axios';
import { Product } from '../../types/Product';

const API_URL = 'http://localhost:5085/api/Product';

// Lấy danh sách sản phẩm
export const getProducts = async () => {
  const res = await axios.get(API_URL);
  return res.data;
};

// Thêm sản phẩm mới
export const addProduct = async (product: Product) => {
  const res = await axios.post(API_URL, product);
  return res.data;
};

// Sửa sản phẩm
export const updateProduct = async (id: number, product: Product) => {
  const res = await axios.put(`${API_URL}/${id}`, product);
  return res.data;
};

// Xóa sản phẩm
export const deleteProduct = async (id: number) => {
  await axios.delete(`${API_URL}/${id}`);
};
