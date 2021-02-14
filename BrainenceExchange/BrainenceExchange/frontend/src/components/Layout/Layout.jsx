import NavMenu from "../NavMenu/NavMenu"
import styles from './LayoutStyle.module.css';

const Layout = (props) => {
    return (
        <>
            <NavMenu />
            <div className={styles.content}>
                {props.children}
            </div>
        </>
    );
}

export default Layout;