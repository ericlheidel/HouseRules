import { useEffect, useState } from "react"
import { getUserProfiles } from "../../managers/userProfileManager.js"
import { Card } from "reactstrap"
import { Link } from "react-router-dom"

export const UserProfileList = () => {
  const [userProfiles, setUserProfiles] = useState([])

  useEffect(() => {
    getUserProfiles().then(setUserProfiles)
  }, [])

  return (
    <div>
      <div>
        <h1>UserProfileList</h1>
        {userProfiles.map((up) => {
          return (
            <Card key={up.id}>
              <Link to={`/userprofiles/${up.id}`}>
                <h3>
                  {up.firstName} {up.lastName}
                </h3>
              </Link>
            </Card>
          )
        })}
      </div>
    </div>
  )
}
