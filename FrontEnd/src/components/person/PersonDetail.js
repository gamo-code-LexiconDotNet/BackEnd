import { Card, Table } from "react-bootstrap";
import { Trash } from "react-bootstrap-icons";
import { useNavigate } from "react-router-dom";

const PersonDetail = ({ person }) => {
  const navigate = useNavigate();

  const handleDelete = () => {
    fetch("/api/person/" + person.id, {
      method: "DELETE",
    }).then(() => {
      navigate("/", { replace: true });
    });
  };

  return (
    <div className="d-flex justify-content-center">
      <Card className="w-50">
        <Card.Body>
          <Card.Title>{person.name}</Card.Title>
          <Table>
            <tbody>
              <tr>
                <th>Phone number</th>
                <td>{person.phonenumber}</td>
              </tr>
              <tr>
                <th>Languages</th>
                <td>
                  {person.languages.map((language) => (
                    <span key={language.id}>
                      {language.name}
                      <br />
                    </span>
                  ))}
                </td>
              </tr>
              <tr>
                <th>City</th>
                <td>{person.city.name}</td>
              </tr>
              <tr>
                <th>Country</th>
                <td>{person.city.countryname}</td>
              </tr>
            </tbody>
          </Table>
          <div className="d-flex justify-content-end">
            <Trash onClick={handleDelete} />
          </div>
        </Card.Body>
      </Card>
    </div>
  );
};

export default PersonDetail;
