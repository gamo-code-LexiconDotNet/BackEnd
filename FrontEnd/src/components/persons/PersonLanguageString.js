const PersonLanguageString = ({ languages }) => {
  return <span>{languages.join(", ")}</span>;
};

export default PersonLanguageString;
