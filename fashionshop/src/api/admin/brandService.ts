import axios from 'axios';

const BRAND_API_URL = 'http://localhost:5085/api/Brand';

export const getBrands = async () => {
  const res = await axios.get(BRAND_API_URL);
  return res.data;
};

export const addBrand = async (brand: { name: string }) => {
  const res = await axios.post(BRAND_API_URL, brand);
  return res.data;
};

export const updateBrand = async (id: number, brand: { name: string }) => {
  const res = await axios.put(`${BRAND_API_URL}/${id}`, brand);
  return res.data;
};

export const deleteBrand = async (id: number) => {
  await axios.delete(`${BRAND_API_URL}/${id}`);
};
