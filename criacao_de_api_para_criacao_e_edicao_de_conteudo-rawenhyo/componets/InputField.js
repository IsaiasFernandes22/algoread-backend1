import React from 'react';

const InputField = ({ label, name, value, onChange, error }) => {
  return (
    <div>
      <label>{label}</label>
      <input
        type="text"
        name={name}
        value={value}
        onChange={onChange}
      />
      {error && <span>{error}</span>}
    </div>
  );
};

export default InputField;
