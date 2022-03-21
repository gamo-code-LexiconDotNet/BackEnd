import LoadingSpinner from "../../components/common/LoadingSpinner";
import PersonTable from "../../components/person/PersonTable";
import useFetch from "../../hooks/useFetch";

const AllPersonsPage = () => {
  const { isLoading, data: persons, fetchError } = useFetch("api/person");

  if (isLoading || fetchError) {
    return <LoadingSpinner error={fetchError} />;
  }

  return <div>{persons && <PersonTable persons={persons} />}</div>;
};

export default AllPersonsPage;
