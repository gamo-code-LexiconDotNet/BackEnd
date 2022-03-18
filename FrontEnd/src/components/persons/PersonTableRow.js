import { Trash, PencilSquare, Search } from "react-bootstrap-icons";

import PersonLanguageString from "./PersonLanguageString";

const PersonItem = ({ person }) => {
  return (
    <tr>
      <td>{person.name}</td>
      <td>{person.phonenumber}</td>
      <td>
        <PersonLanguageString languages={person.languages} />
      </td>
      <td>{person.city}</td>
      <td>{person.country}</td>
      <td>
        <Search />
      </td>
      <td>
        <PencilSquare />
      </td>
      <td>
        <Trash />
      </td>
    </tr>
  );
};

export default PersonItem;
