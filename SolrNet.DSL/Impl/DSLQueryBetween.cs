﻿#region license
// Copyright (c) 2007-2010 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using SolrNet.DSL.Impl;

namespace SolrNet.DSL.Impl {
    public class DSLQueryBetween<T, RT> : IDSLQueryBetween<T, RT> where T : new() {
        private readonly string fieldName;
        private readonly ISolrConnection connection;
        private readonly ISolrQuery query;
        private readonly RT from;

        public DSLQueryBetween(string fieldName, ISolrConnection connection, ISolrQuery query, RT from) {
            this.fieldName = fieldName;
            this.connection = connection;
            this.query = query;
            this.from = from;
        }

        public IDSLQuery<T> And(RT i) {
            return new DSLQuery<T>(connection,
                                   new SolrMultipleCriteriaQuery(
                                       new[] {
                                           query,
                                           new SolrQueryByRange<RT>(fieldName, from, i)
                                       }));
        }
    }
}