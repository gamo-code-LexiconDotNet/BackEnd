import { Route, Routes } from "react-router-dom";

import Layout from "./components/layout/Layout";
import AllPersonsPage from "./pages/AllPersons";

const App = () => {
  return (
    <div>
      <Layout>
        <Routes>
          <Route exact path="/" element={<AllPersonsPage />} />
          <Route exact path="/people" element={<AllPersonsPage />} />
        </Routes>
      </Layout>
    </div>
  );
};

export default App;
