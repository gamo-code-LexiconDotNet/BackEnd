import Table from "react-bootstrap/Table";
import CommaSeparated from "../common/CommaSeparated";

const CountryTable = (props) => {
  return (
    <Table>
      <thead>
        <tr>
          <th>Country</th>
          <th>Cities</th>
        </tr>
      </thead>
      <tbody>
        {props.countries.map((country) => (
          <tr key={country.id}>
            <td>{country.name}</td>
            <td>
              <CommaSeparated items={country.cities} name="name" />
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default CountryTable;
