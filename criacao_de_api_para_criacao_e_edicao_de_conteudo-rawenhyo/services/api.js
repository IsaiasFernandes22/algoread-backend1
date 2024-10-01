export const addReviewer = async (reviewerData) => {
    const response = await fetch('/api/reviewer/add', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(reviewerData),
    });
  
    if (!response.ok) {
      throw new Error('Erro ao adicionar revisor.');
    }
  
    return response.json();
  };
  
  export const assignReviewers = async (contentId) => {
    const response = await fetch(`/api/reviewer/assign-reviews/${contentId}`, {
      method: 'POST',
    });
  
    if (!response.ok) {
      throw new Error('Erro ao atribuir revisores.');
    }
  
    return response.json();
  };
  
  export const getReviewAssignments = async (contentId) => {
    const response = await fetch(`/api/reviewer/assignments/${contentId}`);
  
    if (!response.ok) {
      throw new Error('Erro ao buscar atribuições de revisores.');
    }
  
    return response.json();
  };
  