import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom"
import {
  assignChore,
  getChoreById,
  unassignChore,
  updateChore,
} from "../../managers/choreManager.js"
import { Button, Card, Input } from "reactstrap"
import moment from "moment"
import { getUserProfiles } from "../../managers/userProfileManager.js"

export const ChoreDetails = () => {
  const [chore, setChore] = useState([])
  const [users, setUsers] = useState([])

  const [updatedName, setUpdatedName] = useState("")
  const [updatedDifficulty, setUpdatedDifficulty] = useState(0)
  const [updatedFrequency, setUpdatedFrequency] = useState(0)

  const { id } = useParams()

  const navigate = useNavigate()

  const getAndResetChores = () => {
    getChoreById(id).then(setChore)
  }

  useEffect(() => {
    getAndResetChores()
  }, [])

  useEffect(() => {
    getUserProfiles().then(setUsers)
  }, [])

  const handleCheckboxChange = (e, userId) => {
    const isChecked = e.target.checked

    if (isChecked) {
      assignChore(chore.id, userId).then(getAndResetChores())
    } else {
      unassignChore(chore.id, userId).then(getAndResetChores())
    }
  }

  const handleUpdateChore = () => {
    const updatedChore = {
      name: updatedName !== "" ? updatedName : chore.name,
      difficulty:
        updatedDifficulty !== 0 ? updatedDifficulty : chore.difficulty,
      choreFrequencyDays:
        updatedFrequency !== 0 ? updatedFrequency : chore.choreFrequencyDays,
    }

    updateChore(chore.id, updatedChore).then(() => {
      navigate("/chores")
    })
  }

  return (
    <Card key={chore.id}>
      <h3>Chore:</h3>
      <fieldset>
        <Input
          type="text"
          defaultValue={chore.name}
          onChange={(e) => {
            setUpdatedName(e.target.value)
          }}
        />
      </fieldset>
      <div>
        <h3>Difficulty:</h3>
        <fieldset>
          <Input
            type="number"
            defaultValue={chore.difficulty}
            onChange={(e) => {
              setUpdatedDifficulty(e.target.value)
            }}
          />
        </fieldset>
      </div>
      <fieldset>
        <h3>Frequency (Days):</h3>
        <Input
          type="number"
          defaultValue={chore.choreFrequencyDays}
          onChange={(e) => {
            setUpdatedFrequency(e.target.value)
          }}
        />
      </fieldset>
      <h3 className="mt-3`">
        {chore.choreCompletions?.length > 0 && (
          <div className="mt-3">
            Most Recently Completed on:
            {chore.choreCompletions
              ?.sort(
                (a, b) => new Date(b.completedOn) - new Date(a.completedOn)[0]
              )
              .map((cc) => {
                return (
                  <div key={cc.id}>
                    <h3>
                      {moment(cc.completedOn).format(
                        "dddd, MMMM Do, YYYY [at] h:mm a"
                      )}
                    </h3>
                  </div>
                )
              })}
          </div>
        )}
      </h3>
      <div className="mt-3">
        {users.map((u) => {
          return (
            <div key={u.id}>
              <div>
                <h3>
                  <Input
                    defaultChecked={chore.choreAssignments?.some(
                      (ca) => ca.userProfile.id === u.id
                    )}
                    type="checkbox"
                    className="mx-3"
                    value={u.id}
                    onChange={(e) => {
                      handleCheckboxChange(e, u.id)
                    }}
                  />
                  {u.firstName} {u.lastName}
                </h3>
              </div>
            </div>
          )
        })}
      </div>
      <Button color="primary" className="mt-3" onClick={handleUpdateChore}>
        Submit
      </Button>
    </Card>
  )
}
