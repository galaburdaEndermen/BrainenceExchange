import NavMenu from "../NavMenu/NavMenu"

const Layout = (props) => {
    return (
        <>
            <NavMenu />
            {props.children}
        </>
    );
}

export default Layout;