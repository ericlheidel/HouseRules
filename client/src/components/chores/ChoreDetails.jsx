import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { getChoreById } from "../../managers/choreManager.js"
import { Card } from "reactstrap"
import moment from "moment"

export const ChoreDetails = () => {
  const [chore, setChore] = useState([])
  const { id } = useParams()

  useEffect(() => {
    getChoreById(id).then(setChore)
  }, [id])

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
      <h3 className="mt-3">
        Most Recently Completed on:
        {chore.choreCompletions
          ?.sort((a, b) => new Date(b.completedOn) - new Date(a.completedOn))
          .slice(0, 1)
          .map((cc) => {
            return (
              <div key={cc.id}>
                {moment(cc.completedOn).format(
                  "dddd, MMMM Do, YYYY [at] h:mm a"
                )}
              </div>
            )
          })}
      </h3>
    </Card>
  )
}
