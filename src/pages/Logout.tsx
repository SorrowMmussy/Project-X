import { Cookies } from 'react-cookie';

const Logout = () => {
    const cookies = new Cookies();

    cookies.remove('jwt');

    return <></>;
};

export default Logout;
