# FriendsRecommendator
Recommend friends of friends in social media 

# Technical specification
Code build on C# .net8 as a web api. Clone the repository on local machine and can run on both VScode 
as well as visual studio 2022 community IDE

## Dummy User Data  stored in the users.json file. See the below dummy data
[
  {
    "UserId": 1,
    "UserName": "Sudesh"
  },
  {
    "UserId": 2,
    "UserName": "Rohit"
  },
  {
    "UserId": 3,
    "UserName": "Rajat"
  },
  {
    "UserId": 4,
    "UserName": "Darshan"
  },
  {
    "UserId": 5,
    "UserName": "Maria"
  },
  {
    "UserId": 6,
    "UserName": "Mahesh"
  },
  {
    "UserId": 7,
    "UserName": "Vignesh"
  },
  {
    "UserId": 8,
    "UserName": "Michael"
  },
  {
    "UserId": 9,
    "UserName": "Karl"
  },
  {
    "UserId": 10,
    "UserName": "Rasmus"
  },
  {
    "UserId": 11,
    "UserName": "Kristian"
  },
  {
    "UserId": 12,
    "UserName": "Jonas"
  }
]

## Dummy Friend list mapping mentioned below

  var map = new Dictionary<int, List<int>>()
          {
              {1,new List<int>{2,3,4}},
              {2,new List<int>{1,3,5,6}},
              {3,new List<int>{1,2,6}},
              {4,new List<int>{1,5,7,8}},
              {5,new List<int>{2,4,6}},
              {6,new List<int>{2,3,5,9}},
              {7,new List<int>{4,9}},
              {8,new List<int>{4}},
              {9,new List<int>{6,7}},
              {10,new List<int>{11}},
              {11,new List<int>{10}},
          };

