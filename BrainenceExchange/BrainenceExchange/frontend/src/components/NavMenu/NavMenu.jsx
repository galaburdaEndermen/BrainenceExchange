import styles from './NavMenuStyle.module.css';
import { useHistory } from 'react-router-dom';

const NavMenu = () => {
    let history = useHistory();

    return (
        <>
            <div className={styles.container}>

                <div className={styles.link}
                    onClick={() => {
                        history.push('/');
                    }}>Exchange</div>

                <div className={styles.link}
                    onClick={() => {
                        history.push('/history');
                    }}>History</div>

            </div>
        </>
    );
}

export default NavMenu;