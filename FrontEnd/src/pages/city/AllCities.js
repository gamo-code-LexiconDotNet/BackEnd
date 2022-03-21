import CityTable from "../../components/city/CityTable";
import LoadingSpinner from "../../components/common/LoadingSpinner";
import useFetch from "../../hooks/useFetch";

const AllCitiesPage = () => {
  const { isLoading, data: cities, fetchError } = useFetch("api/city");

  if (isLoading || fetchError) {
    return <LoadingSpinner error={fetchError} />;
  }

  return <div>{cities && <CityTable cities={cities} />}</div>;
};

export default AllCitiesPage;
