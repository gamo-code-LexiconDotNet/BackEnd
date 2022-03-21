const CommaSeparated = ({ items, name }) => {
  let content = [];
  for (let [i, item] of items.entries()) {
    content.push(
      <span className="comma" key={i}>
        {item[name]}
      </span>
    );
  }

  return <>{content}</>;
};

export default CommaSeparated;
