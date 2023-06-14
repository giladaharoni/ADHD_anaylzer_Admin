import requests
import calendar
import time

# try to register
# try to login
# insert new processData
# get the processData
# insert quiz answer
# get the quiz answer

base_url = "https://adhdanaylzeradminapi.azurewebsites.net/api/"

register = "User/register?username={username}&fullname={fullname}&password={password}"
login = "Users/login?username={username}&password={password}"
update_user = "Users/register?username={username}&fullname={fullname}&password={password}"
insert_data = "ProcessData?username={username}"
get_data = "ProcessData?username={username}&session={sessionId}"
question = "QuizAnswers?username={username}"

# variables
username = "exe2"
fuulname = "Gilad"
password = "exe2"

counter = 0

try_regitser = requests.get(base_url + register.format(username=username, fullname=fuulname, password=password))
if try_regitser.status_code == 400:
    print("register function was correct, existed user")
    counter += 1
else:
    print("register success")
    counter += 1
try_login = requests.get(base_url + login.format(username=username, password=password))
if try_regitser.status_code == 400:
    print("login failed")
else:
    print("login successed")
    counter += 1
try_update_user = requests.put(base_url + update_user.format(username=username, fullname=fuulname, password=password))
if try_update_user.status_code == 400:
    print("update user failed")
else:
    print("update user successed")
    counter += 1

current_GMT = time.gmtime()
time_stamp = calendar.timegm(current_GMT)
sessionID = 0
process_data_unit = {
    "sessionId": sessionID,
    "timestamp": time_stamp,
    "stayInPlace": False,
    "highAdhd": False
}
try_insert_data = requests.post(base_url + insert_data.format(username=username), json=[process_data_unit])
if try_insert_data.status_code == 400:
    print("inserting processs data failed")
else:
    print("inserting processs data successed")
    counter += 1
try_get_data = requests.get(base_url + get_data.format(username=username, sessionId=sessionID))
process_data_unit["createdByUser"] = username
if try_get_data.status_code == 400:
    print("getting processs data failed")
else:
    print("inserting processs data successed")
    counter += 1

answer = {
    "questionNumber": 0,
    "answer": 0
}

try_insert_question = requests.post(base_url + question.format(username=username), json=[answer])
if try_insert_question.status_code == 400:
    print("insert answers failed")
else:
    print("insert answers succseed")
    counter += 1

answer["answerByUserName"] = username
try_get_questions = requests.get(base_url + question.format(username=username))
if try_get_questions.status_code == 400:
    print("getting answers failed")
else:
    marker = False
    for quiz in try_get_questions.json():
        if quiz == answer:
            print("inserting answers successed")
            counter += 1
            marker = True
            break
    if not marker:
        print("getting answers failed")

print("*****************************************")
print("you got {0} from 7 functions".format(counter))
