import { useState, useEffect } from "react";

import Spinner from "react-bootstrap/Spinner";

import PersonTable from "../components/persons/PersonTable";

const AllPersonsPage = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [loadedPersons, setLoadedPersons] = useState([]);

  useEffect(() => {
    setIsLoading(true);
    fetch("api/people")
      .then((responce) => {
        return responce.json();
      })
      .then((data) => {
        setIsLoading(false);
        setLoadedPersons(data);
      });
  }, []);

  if (isLoading) {
    return (
      <Spinner animation="border" role="status">
        <span className="visually-hidden">Loading...</span>
      </Spinner>
    );
  }

  return (
    <div>
      <h1>People</h1>
      <PersonTable persons={loadedPersons} />
    </div>
  );
};

export default AllPersonsPage;
