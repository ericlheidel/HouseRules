const _apiUrl = "/api/chore"

export const getChores = () => {
  return fetch(_apiUrl).then((res) => res.json())
}
