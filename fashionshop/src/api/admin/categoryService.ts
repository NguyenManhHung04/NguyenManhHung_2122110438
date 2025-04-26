import axios from 'axios';

const CATEGORY_API_URL = 'http://localhost:5085/api/Category';

export const getCategories = async () => {
  const res = await axios.get(CATEGORY_API_URL);
  return res.data;
};

export const addCategory = async (category: { name: string }) => {
  const res = await axios.post(CATEGORY_API_URL, category);
  return res.data;
};

export const updateCategory = async (id: number, category: { name: string }) => {
  const res = await axios.put(`${CATEGORY_API_URL}/${id}`, category);
  return res.data;
};

export const deleteCategory = async (id: number) => {
  await axios.delete(`${CATEGORY_API_URL}/${id}`);
};
