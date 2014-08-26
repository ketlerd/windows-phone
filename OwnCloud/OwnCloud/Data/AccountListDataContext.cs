﻿using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace OwnCloud.Data
{
    public class AccountListDataContext : Entity
    {
        public AccountListDataContext()
        {
            Loaddata();
        }

        public ObservableCollection<Account> Accounts
        {
            get;
            set;
        }

        public void Loaddata()
        {
            Accounts = new ObservableCollection<Account>();
            
            // protect us from zombie binding trigger values
            App.DataContext.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, App.DataContext.Accounts);

            foreach (Account account in App.DataContext.Accounts)
            {
                // Only add the account, if CalDAV was set up
                if (!account.CalDAVPath.Equals(""))
                {
                    Accounts.Add(account);
                }
            }
        }
    }
}
