import { Link } from "react-router-dom";

function MainNavigation() {
  return (
    <header>
      <div>
        <h1>People, Languages, Cities and Countries</h1>
      </div>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/people">People</Link>
          </li>
          <li>
            <Link to="/languages">Languages</Link>
          </li>
          <li>
            <Link to="/cities">Cities</Link>
          </li>
          <li>
            <Link to="/countries">Countries</Link>
          </li>
        </ul>
      </nav>
    </header>
  );
}

export default MainNavigation;
