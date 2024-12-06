import { useEffect } from 'react';
import { useNavigate, useSearchParams } from 'react-router-dom';
import { message } from 'antd';
import { ROUTERS } from '../../utils/router';

const GoogleCallback = () => {
    const navigate = useNavigate();
    const [searchParams] = useSearchParams();

    useEffect(() => {
        const success = searchParams.get('success');
        const errorMessage = searchParams.get('error');
        const successMessage = searchParams.get('message');

        if (success === 'true' && successMessage) {
            // Hiển thị thông báo thành công
            message.success(decodeURIComponent(successMessage));
            // Chuyển hướng về trang chủ
            navigate(ROUTERS.USER.HOME);
        } else if (errorMessage) {
            // Hiển thị thông báo lỗi
            message.error(decodeURIComponent(errorMessage));
            // Chuyển hướng về trang đăng nhập
            navigate(ROUTERS.USER.LOGIN);
        }
    }, [navigate, searchParams]);

    return (
        <div style={{ 
            display: 'flex', 
            justifyContent: 'center', 
            alignItems: 'center', 
            height: '100vh' 
        }}>
            Đang xử lý đăng nhập...
        </div>
    );
};

export default GoogleCallback;