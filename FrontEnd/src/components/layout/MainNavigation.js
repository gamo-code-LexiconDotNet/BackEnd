import { Link } from "react-router-dom";
import { Container, Nav, Navbar } from "react-bootstrap";

function MainNavigation() {
  return (
    <header>
      <Navbar>
        <Container>
          <Navbar.Brand as={Link} to="/">
            MVC FrontEnd
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="navbar" />
          <Navbar.Collapse id="navbar" className="justify-content-end">
            <Nav>
              <Nav.Item>
                <Nav.Link as={Link} to="/people">
                  People
                </Nav.Link>
              </Nav.Item>
              <Nav.Item>
                <Nav.Link as={Link} to="/languages">
                  Languages
                </Nav.Link>
              </Nav.Item>
              <Nav.Item>
                <Nav.Link as={Link} to="/cities">
                  Cities
                </Nav.Link>
              </Nav.Item>
              <Nav.Item>
                <Nav.Link as={Link} to="/countries">
                  Countries
                </Nav.Link>
              </Nav.Item>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </header>
  );
}

export default MainNavigation;
