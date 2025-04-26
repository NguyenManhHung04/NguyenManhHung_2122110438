import React, { useEffect, useState } from 'react';
import { getCategories } from '../../../api/user/categoryService'; // API gọi từ ASP.NET
import { Category } from '../../../types/Category'; // Model chuẩn
import '../../../assets/css/reset.css';
import '../../../assets/css/HotCategory.css';

const HotCategory: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const data = await getCategories();
        setCategories(data);
      } catch (error) {
        console.error('Error fetching categories:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchCategories();
  }, []);

  if (loading) {
    return <p>Loading categories...</p>; // Bạn có thể thay bằng Skeleton đẹp hơn
  }

  return (
    <section className="hot-category-layout">
      <div className="hot-category-container">
      
        {categories.map((category) => (
          <div key={category.id} className="hot-category-item">
            <div className="hot-category-text">
            
              <span className="category-title">{category.name}</span>
              <span className="category-season">{category.description}</span>
            </div>
            <div className="hot-category-image">
              <img 
                src={category.image ? `http://localhost:5085/images/${category.image}` : '/default-image.jpg'}
                alt={category.name}
                loading="lazy"
              />
            </div>
          </div>
        ))}
      </div>
    </section>
  );
};

export default HotCategory;
