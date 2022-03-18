import PersonTableRow from "./PersonTableRow";

const PersonTable = (props) => {
  return (
    <table>
      <thead>{}</thead>
      <tbody>
        {props.persons.map((person) => (
          <PersonTableRow key={person.id} person={person} />
        ))}
      </tbody>
    </table>
  );
};

export default PersonTable;
