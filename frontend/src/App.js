import { Route, Routes } from "react-router-dom";

import Layout from "./components/layout/Layout";
import AllCitiesPage from "./pages/city/AllCities";
import AllCountriesPage from "./pages/country/AllCountries";
import AllLanguagesPage from "./pages/language/AllLanguages";
import AllPersonsPage from "./pages/person/AllPersons";
import DetailPersonPage from "./pages/person/DetailPerson";
import NewPersonPage from "./pages/person/NewPerson";

const App = () => {
  return (
    <div>
      <Layout>
        <Routes>
          <Route exact path="/" element={<AllPersonsPage />} />
          <Route exact path="/people" element={<AllPersonsPage />} />
          <Route exact path="/people/:id" element={<DetailPersonPage />} />
          <Route exact path="/people/new" element={<NewPersonPage />} />
          <Route exact path="/cities" element={<AllCitiesPage />} />
          <Route exact path="/countries" element={<AllCountriesPage />} />
          <Route exact path="/languages" element={<AllLanguagesPage />} />
        </Routes>
      </Layout>
    </div>
  );
};

export default App;
