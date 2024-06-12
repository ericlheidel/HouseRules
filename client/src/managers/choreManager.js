const _apiUrl = "/api/chore"

export const getChores = () => {
  return fetch(_apiUrl).then((res) => res.json())
}

export const getChoreById = (id) => {
  return fetch(_apiUrl + `/${id}`).then((res) => res.json())
}

export const createChore = (chore) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(chore),
  })
}

export const completeChore = (cId, userId) => {
  return fetch(_apiUrl + `/${cId}/complete?userId=${userId}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  })
}

export const deleteChore = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  })
}

export const assignChore = (id, userId) => {
  return fetch(_apiUrl + `/${id}/assign?userId=${userId}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  })
}

export const unassignChore = (id, userId) => {
  return fetch(`${_apiUrl}/${id}/unassign?userId=${userId}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  })
}
