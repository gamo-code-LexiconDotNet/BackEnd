import Container from "react-bootstrap/Container";

import MainNavigation from "./MainNavigation";

function Layout(props) {
  return (
    <Container>
      <MainNavigation />
      <main>{props.children}</main>
    </Container>
  );
}

export default Layout;
