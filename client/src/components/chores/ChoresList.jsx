/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import { deleteChore, getChores } from "../../managers/choreManager.js"
import { Button, Card } from "reactstrap"
import { useNavigate } from "react-router-dom"

export const ChoresList = ({ loggedInUser }) => {
  const [chores, setChores] = useState([])

  const navigate = useNavigate()

  useEffect(() => {
    getChores().then(setChores)
  }, [])

  const handleDelete = (id) => {
    deleteChore(id).then(() => {
      getChores().then(setChores)
    })
  }

  return (
    <div>
      {chores.map((c) => {
        return (
          <Card key={c.id} className="mt-3">
            <h2>
              <u>{c.name}</u>
            </h2>
            <h3>
              Difficulty{" - "}
              <b>
                {c.difficulty == 1 && "Easy"}
                {c.difficulty == 2 && "Easy-Medium"}
                {c.difficulty == 3 && "Medium"}
                {c.difficulty == 4 && "Medium-Hard"}
                {c.difficulty == 5 && "Hard"}
              </b>
            </h3>
            <h3>
              Frequency{" - "}
              {c.choreFrequencyDays}
              {c.choreFrequencyDays == 1 ? " Day" : " Days"}
            </h3>
            {loggedInUser.roles.includes("Admin") && (
              <div>
                <Button
                  block
                  color="danger"
                  onClick={() => {
                    handleDelete(c.id)
                  }}
                >
                  Delete
                </Button>
                <Button
                  block
                  className="mt-3"
                  color="success"
                  onClick={() => {
                    navigate(`/chores/${c.id}`)
                  }}
                >
                  Details
                </Button>
              </div>
            )}
          </Card>
        )
      })}
    </div>
  )
}
