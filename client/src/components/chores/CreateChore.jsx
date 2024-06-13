import { useState } from "react"
import {
  Button,
  Form,
  /* FormFeedback, */ FormGroup,
  Input,
  Label,
} from "reactstrap"
import { createChore } from "../../managers/choreManager.js"
import { useNavigate } from "react-router-dom"

export const CreateChore = () => {
  const [choreName, setChoreName] = useState("")
  const [difficulty, setDifficulty] = useState(0)
  const [frequency, setFrequency] = useState(0)

  const [errors, setErrors] = useState({})

  const navigate = useNavigate()

  // const handleSubmit = (e) => {
  //   e.preventDefault()

  //   const newChore = {
  //     name: choreName,
  //     difficulty: parseInt(difficulty),
  //     choreFrequencyDays: parseInt(frequency),
  //   }

  //   createChore(newChore).then(() => {
  //     navigate("/chores")
  //   })
  // }

  // hfdsakjhfdaskfhdksajfhaksdjlhfkadsjlfhksjahfkdjsahfaskjdhfkjfdhsafkjasdhfdkjsfhksjadhfkadljhfsakjhfkjdashfkajsdhfksjdfhkdsdfhkjsahfsdkjhfaksdfjhsakdh`5`

  const handleCreateChore = (evt) => {
    evt.preventDefault()

    const newChore = {
      name: choreName,
      difficulty: parseInt(difficulty),
      choreFrequencyDays: parseInt(frequency),
    }

    createChore(newChore).then((res) => {
      if (res.errors) {
        setErrors(res.errors)
      } else {
        navigate("/chores")
      }
    })
  }

  const handleChoreNameChange = (e) => {
    setChoreName(e.target.value)
  }

  const handleDifficultyChange = (e) => {
    setDifficulty(e.target.value)
  }
  const handleFrequencyChange = (e) => {
    setFrequency(e.target.value)
  }

  return (
    <>
      <div style={{ color: "red" }}>
        {errors &&
          Object.keys(errors).map((key) => (
            <p key={key}>{errors[key].join(",")}</p>
          ))}
      </div>
      <Form>
        <FormGroup>
          <Label for="chore">Chore</Label>
          <Input id="chore" onChange={handleChoreNameChange} />
        </FormGroup>
        <FormGroup>
          <Label for="difficulty">Difficulty Level (1 - 5)</Label>
          <Input
            type="number"
            id="difficulty"
            onChange={handleDifficultyChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="frequency">Chore Frequency (# of Days)</Label>
          <Input
            type="number"
            id="frequency"
            onChange={handleFrequencyChange}
          />
          <datalist id="frequencyOptions">
            <option value="1" />
            <option value="3" />
            <option value="7" />
            <option value="10" />
            <option value="14" />
          </datalist>
        </FormGroup>
        <FormGroup>
          <Button type="submit" color="primary" onClick={handleCreateChore}>
            Submit
          </Button>
        </FormGroup>
      </Form>
    </>
  )
}
