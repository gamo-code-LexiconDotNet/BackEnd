import { useMemo, useState } from "react";
import { PlusSquare, Search } from "react-bootstrap-icons";
import Table from "react-bootstrap/Table";
import { Link } from "react-router-dom";
import CommaSeparated from "../common/CommaSeparated";

// sorting base code from https://www.smashingmagazine.com/2020/03/sortable-tables-react/
const useSortableData = (items, config = null) => {
  const [sortConfig, setSortConfig] = useState(config);

  const sortedItems = useMemo(() => {
    let sortableItems = [...items];
    if (sortConfig !== null) {
      sortableItems.sort((a, b) => {
        if (a[sortConfig.key] < b[sortConfig.key]) {
          return sortConfig.direction === "ascending" ? -1 : 1;
        }
        if (a[sortConfig.key] > b[sortConfig.key]) {
          return sortConfig.direction === "ascending" ? 1 : -1;
        }
        return 0;
      });
    }
    return sortableItems;
  }, [items, sortConfig]);

  const requestSort = (key) => {
    let direction = "ascending";
    if (
      sortConfig &&
      sortConfig.key === key &&
      sortConfig.direction === "ascending"
    ) {
      direction = "descending";
    }
    setSortConfig({ key, direction });
  };

  return { items: sortedItems, requestSort, sortConfig };
};

const PersonTable = ({ persons }) => {
  const { items, requestSort } = useSortableData(persons);

  return (
    <>
      <Table>
        <thead>
          <tr>
            <th>
              <span
                style={{ borderBottom: "1px dashed #000", cursor: "pointer" }}
                onClick={() => requestSort("name")}
              >
                Name
              </span>
            </th>
            <th>
              <span>Phone Number</span>
            </th>
            <th>
              <span>Languages</span>
            </th>
            <th>
              <span>City</span>
            </th>
            <th>
              <span>Country</span>
            </th>
          </tr>
        </thead>
        <tbody>
          {items.map((person) => (
            <tr key={person.id}>
              <td>{person.name}</td>
              <td>{person.phonenumber}</td>
              <td>
                <CommaSeparated items={person.languages} name="name" />
              </td>
              <td>{person.city.name}</td>
              <td>{person.city.countryname}</td>
              <td className="text-end">
                <Link className="p-2 link-dark" to={`/people/${person.id}`}>
                  <Search />
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      <div className="d-flex justify-content-end">
        <Link className="pe-3 link-dark" to={"/people/new"}>
          <PlusSquare />
        </Link>
      </div>
    </>
  );
};

export default PersonTable;
