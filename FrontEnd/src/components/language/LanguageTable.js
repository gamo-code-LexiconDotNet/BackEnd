import Table from "react-bootstrap/Table";
import CommaSeparated from "../common/CommaSeparated";

const LanguageTable = (props) => {
  return (
    <Table>
      <thead>
        <tr>
          <th>Languages</th>
          <th>People</th>
        </tr>
      </thead>
      <tbody>
        {props.languages.map((language) => (
          <tr key={language.id}>
            <td>{language.name}</td>
            <td>
              <CommaSeparated items={language.persons} name="name" />
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
};

export default LanguageTable;
