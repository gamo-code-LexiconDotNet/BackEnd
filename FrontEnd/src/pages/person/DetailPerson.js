import { useParams } from "react-router-dom";
import LoadingSpinner from "../../components/common/LoadingSpinner";
import PersonDetail from "../../components/person/PersonDetail";
import useFetch from "../../hooks/useFetch";

const DetailPersonPage = () => {
  const { id } = useParams();
  const { isLoading, data: person, fetchError } = useFetch(`/api/person/${id}`);

  if (isLoading || fetchError) {
    return <LoadingSpinner error={fetchError} />;
  }

  return <>{person && <PersonDetail person={person} />}</>;
};

export default DetailPersonPage;
