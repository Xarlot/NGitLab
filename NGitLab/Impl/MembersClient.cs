﻿using System;
using System.Collections.Generic;
using System.Net;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class MembersClient : IMembersClient
    {
        private readonly API _api;

        public MembersClient(API api)
        {
            _api = api;
        }

        private IEnumerable<Membership> GetAll(string url, bool includeInheritedMembers)
        {
            url += "/members";
            if (includeInheritedMembers)
            {
                url += "/all";
            }

            return _api.Get().GetAll<Membership>(url);
        }

        public IEnumerable<Membership> OfProject(string projectId)
        {
            return OfProject(projectId, includeInheritedMembers: false);
        }

        public IEnumerable<Membership> OfProject(string projectId, bool includeInheritedMembers)
        {
            return GetAll(Project.Url + "/" + WebUtility.UrlEncode(projectId), includeInheritedMembers);
        }

        [Obsolete("Use OfGroup")]
        public IEnumerable<Membership> OfNamespace(string groupId)
        {
            return OfGroup(groupId);
        }

        public IEnumerable<Membership> OfGroup(string groupId)
        {
            return OfGroup(groupId, includeInheritedMembers: false);
        }

        public IEnumerable<Membership> OfGroup(string groupId, bool includeInheritedMembers)
        {
            return GetAll(GroupsClient.Url + "/" + WebUtility.UrlEncode(groupId), includeInheritedMembers);
        }

        public Membership GetMemberOfGroup(string groupId, string userId)
        {
            return _api.Get().To<Membership>(GroupsClient.Url + "/" + WebUtility.UrlEncode(groupId) + "/members/" + WebUtility.UrlEncode(userId));
        }

        public Membership AddMemberToProject(string projectId, ProjectMemberCreate user)
        {
            return _api.Post().With(user).To<Membership>(Project.Url + "/" + WebUtility.UrlEncode(projectId) + "/members");
        }
    }
}