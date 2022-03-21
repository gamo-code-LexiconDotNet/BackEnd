import { Spinner } from "react-bootstrap";

const LoadingSpinner = ({ error }) => {
  return (
    <div className="d-flex flex-column justify-content-center align-items-center">
      {!error && (
        <Spinner animation="border" role="status">
          <span className="visually-hidden">Loading...</span>
        </Spinner>
      )}
      {error && <div>{error}</div>}
    </div>
  );
};

export default LoadingSpinner;
