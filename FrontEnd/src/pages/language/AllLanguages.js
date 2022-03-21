import LoadingSpinner from "../../components/common/LoadingSpinner";
import LanguageTable from "../../components/language/LanguageTable";
import useFetch from "../../hooks/useFetch";

const AllLanguagesPage = () => {
  const { isLoading, data: languages, fetchError } = useFetch("api/language");

  if (isLoading || fetchError) {
    return <LoadingSpinner error={fetchError} />;
  }

  return <div>{languages && <LanguageTable languages={languages} />}</div>;
};

export default AllLanguagesPage;
