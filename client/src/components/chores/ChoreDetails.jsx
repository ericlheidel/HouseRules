import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import {
  assignChore,
  getChoreById,
  unassignChore,
} from "../../managers/choreManager.js"
import { Card, Input } from "reactstrap"
import moment from "moment"
import { getUserProfiles } from "../../managers/userProfileManager.js"

export const ChoreDetails = () => {
  const [chore, setChore] = useState([])
  const [users, setUsers] = useState([])

  const { id } = useParams()

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

  return (
    <Card key={chore.id}>
      <h2>
        <u>{chore.name}</u>
      </h2>
      <h3>
        Difficulty{" - "}
        <b>
          {chore.difficulty == 1 && "Easy"}
          {chore.difficulty == 2 && "Easy-Medium"}
          {chore.difficulty == 3 && "Medium"}
          {chore.difficulty == 4 && "Medium-Hard"}
          {chore.difficulty == 5 && "Hard"}
        </b>
      </h3>
      <h3>
        Frequency{" - "}
        {chore.choreFrequencyDays}
        {chore.choreFrequencyDays == 1 ? " Day" : " Days"}
      </h3>
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
                    // checked={isUserAssigned(u.id)}
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
    </Card>
  )
}
