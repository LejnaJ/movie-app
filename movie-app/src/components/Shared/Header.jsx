import { Nav } from 'react-bootstrap';
const Header = () => {
    return (
        <div className="header">
            <div className="container">
                <div className="logo">
                    <a href="/">
                    <h1>Movie App</h1>
                    </a>
                </div>
                <Nav>
                    <Nav.Link href="/">Home</Nav.Link>
                </Nav>
            </div>
        </div>

    )
};
export default Header;