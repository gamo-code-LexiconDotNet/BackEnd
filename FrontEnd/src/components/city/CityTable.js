import Table from "react-bootstrap/Table";

const CityTable = (props) => {
  return (
    <Table>
      <thead>
        <tr>
          <th>City</th>
          <th>Country</th>
        </tr>
      </thead>
      <tbody>
        {props.cities.map((city) => (
          <tr key={city.id}>
            <td>{city.name}</td>
            <td>{city.countryname}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default CityTable;
