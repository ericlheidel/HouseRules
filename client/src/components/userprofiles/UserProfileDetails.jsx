import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { Card } from "reactstrap"
import { getUser } from "../../managers/userProfileManager.js"
import moment from "moment"

export const UserProfileDetails = () => {
  const [user, setUser] = useState([])
  const { id } = useParams()

  useEffect(() => {
    getUser(id).then(setUser)
  }, [id])

  return (
    <Card>
      <h2>
        <u>
          {user.firstName} {user.lastName}
        </u>
      </h2>
      <h3>Address: {user.address}</h3>
      <h3>Email: {user.email}</h3>
      <h3>Username: {user.userName}</h3>
      <h3
        className="mt-5
      "
      >
        <u>Current Chores ({user.choreAssignments?.length})</u>
        {user.choreAssignments?.map((ca) => {
          return (
            <div key={ca.id} className="mt-3">
              {ca.chore.name}
            </div>
          )
        })}
      </h3>
      <h3 className="mt-5">
        <u>Completed Chores ({user.choreCompletions?.length})</u>
      </h3>
      <h3>
        {user.choreCompletions?.map((cc) => {
          return (
            <div key={cc.id} className="mt-3">
              {cc.chore.name}
              {" - "}
              {moment(cc.completedOn).format("dddd, MMMM Do, YYYY [at] h:mm a")}
            </div>
          )
        })}
      </h3>
    </Card>
  )
}
