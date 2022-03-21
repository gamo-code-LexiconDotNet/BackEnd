import { useState } from "react";
import { Button, Container, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import LoadingSpinner from "../../components/common/LoadingSpinner";
import useFetchLists from "../../hooks/useFetchLists";

const NewPersonPage = () => {
  const navigate = useNavigate();

  const [name, setName] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [language, setLanguage] = useState(1);
  const [city, setCity] = useState(1);

  const [isLoading, setIsLoading] = useState(false);
  const [fetchError, setFetchError] = useState(false);

  const {
    isLoading: isLoadingLists,
    data: lists,
    fetchError: fetchErrorLists,
  } = useFetchLists();

  if (isLoadingLists || fetchErrorLists) {
    return <LoadingSpinner error={fetchErrorLists} />;
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    const newPerson = {
      name: name,
      phonenumber: phoneNumber,
      languageid: language,
      cityid: city,
    };

    setIsLoading(true);
    setFetchError(false);

    fetch("/api/person", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newPerson),
    })
      .then((res) => {
        console.log("new person created");
        if (!res.ok) {
          throw Error();
        }
      })
      .then(() => {
        navigate("/", { replace: true });
      })
      .catch((err) => {
        console.log(err.message);
        setIsLoading(false);
        setFetchError(true);
      });

    setIsLoading(false);
  };

  return (
    <Container className="col-8">
      <h3 className="mb-3">New person</h3>
      <Form onSubmit={handleSubmit}>
        <Form.Group className="mb-3">
          <Form.Label>Name</Form.Label>
          <Form.Control
            type="text"
            required
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Phone number</Form.Label>
          <Form.Control
            type="text"
            required
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Language</Form.Label>
          <Form.Select
            value={language}
            onChange={(e) => setLanguage(e.target.value)}
          >
            {lists.languages.map((language) => (
              <option key={language.id} value={language.id}>
                {language.name}
              </option>
            ))}
          </Form.Select>
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>City</Form.Label>
          <Form.Select value={city} onChange={(e) => setCity(e.target.value)}>
            {lists.cities.map((city) => (
              <option key={city.id} value={city.id}>
                {city.name}
              </option>
            ))}
          </Form.Select>
        </Form.Group>
        {!isLoading && <Button type="submit">Add person</Button>}
        {isLoading && (
          <Button disabled type="submit">
            Saving person
          </Button>
        )}
        {fetchError && (
          <div className="mt-2 text-danger">Could not add person.</div>
        )}
      </Form>
    </Container>
  );
};

export default NewPersonPage;
