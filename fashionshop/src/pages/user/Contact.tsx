import React from 'react';
import '../../assets/css/Contact.css'; // Import file CSS nếu cần

const Contact: React.FC = () => {
  return (
    <div className="contact-page container py-5">
      <h1 className="text-center mb-4">Liên Hệ</h1>
      <p className="text-center mb-5">
        Nếu bạn có bất kỳ câu hỏi nào, vui lòng liên hệ với chúng tôi qua biểu mẫu dưới đây.
      </p>

      <form className="contact-form mx-auto" style={{ maxWidth: '600px' }}>
        <div className="mb-3">
          <label htmlFor="name" className="form-label">
            Họ và Tên
          </label>
          <input
            type="text"
            className="form-control"
            id="name"
            placeholder="Nhập họ và tên của bạn"
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="email" className="form-label">
            Email
          </label>
          <input
            type="email"
            className="form-control"
            id="email"
            placeholder="Nhập email của bạn"
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="message" className="form-label">
            Tin nhắn
          </label>
          <textarea
            className="form-control"
            id="message"
            rows={5}
            placeholder="Nhập tin nhắn của bạn"
            required
          ></textarea>
        </div>
        <button type="submit" className="btn btn-primary w-100">
          Gửi
        </button>
      </form>
    </div>
  );
};

export default Contact;