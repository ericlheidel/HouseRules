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
  }).then((res) => {
    // Check to see if the response has a body
    if (res.status === 204) {
      // if the POST was successful, it should return 204 No Content
      // so let's read the response body as text
      // res.text() returns a promise
      // the following .then() will handle that returned promise
      // / following--> => if the response contains text, parse text as JSON, if response is empty,
      //   then return empty object {}
      return res.text().then((text) => (text ? JSON.parse(text) : {}))
    }
    // if the response status code is not a 204, i.e. it is a 400 with errors, the response is parsed as JSON so the event handler can display the errors in the DOM
    return res.json()
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

export const updateChore = (id, chore) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(chore),
  })
}
