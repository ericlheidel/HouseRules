const _apiUrl = "/api/userprofile"

export const getUserProfiles = () => {
  return fetch(_apiUrl).then((res) => res.json())
}

export const getUser = (id) => {
  return fetch(_apiUrl + `/${id}`).then((res) => res.json())
}
