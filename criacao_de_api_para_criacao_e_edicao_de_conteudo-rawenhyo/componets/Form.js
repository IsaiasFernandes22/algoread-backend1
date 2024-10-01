import React, { useState } from 'react';
import InputField from './InputField.js';
import { submitContent } from '../services/api';

const Form = () => {
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    tags: '',
  });
  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const validate = () => {
    let formErrors = {};
    if (!formData.title) formErrors.title = 'Título é obrigatório';
    if (!formData.description) formErrors.description = 'Descrição é obrigatória';
    if (!formData.tags) formErrors.tags = 'Tags são obrigatórias';

    setErrors(formErrors);
    return Object.keys(formErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (validate()) {
      try {
        await submitContent(formData);
        alert('Conteúdo enviado com sucesso!');
      } catch (error) {
        alert('Erro ao enviar conteúdo.');
      }
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <InputField
        label="Título"
        name="title"
        value={formData.title}
        onChange={handleChange}
        error={errors.title}
      />
      <InputField
        label="Descrição"
        name="description"
        value={formData.description}
        onChange={handleChange}
        error={errors.description}
      />
      <InputField
        label="Tags"
        name="tags"
        value={formData.tags}
        onChange={handleChange}
        error={errors.tags}
      />
      <button type="submit">Enviar</button>
    </form>
  );
};

export default Form;
