/* eslint-disable react/prop-types */
import { Route, Routes } from "react-router-dom"
import Login from "./auth/Login"
import Register from "./auth/Register"
import { AuthorizedRoute } from "./auth/AuthorizedRoute.jsx"
import { Home } from "./home/Home.jsx"
import { UserProfileList } from "./userprofiles/UserProfileList.jsx"
import { UserProfileDetails } from "./userprofiles/UserProfileDetails.jsx"
import { ChoresList } from "./chores/ChoresList.jsx"
import { ChoreDetails } from "./chores/ChoreDetails.jsx"
import { CreateChore } from "./chores/CreateChore.jsx"

// eslint-disable-next-line no-unused-vars
export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="userprofiles"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <UserProfileList />
            </AuthorizedRoute>
          }
        />
        <Route
          path="userprofiles/:id"
          element={
            <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
              <UserProfileDetails />
            </AuthorizedRoute>
          }
        />
        <Route path={"chores"}>
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <ChoresList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <ChoreDetails />
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <CreateChore />
              </AuthorizedRoute>
            }
          />
        </Route>
      </Route>
    </Routes>
  )
}
