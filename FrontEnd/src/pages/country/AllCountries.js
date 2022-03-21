import LoadingSpinner from "../../components/common/LoadingSpinner";
import CountryTable from "../../components/country/CountryTable";
import useFetch from "../../hooks/useFetch";

const AllCountriesPage = () => {
  const { isLoading, data: countries, fetchError } = useFetch("api/country");

  if (isLoading || fetchError) {
    return <LoadingSpinner error={fetchError} />;
  }

  return <div>{countries && <CountryTable countries={countries} />}</div>;
};

export default AllCountriesPage;
